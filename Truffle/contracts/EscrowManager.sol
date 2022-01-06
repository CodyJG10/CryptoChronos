//SPDX-License-Identifier: MIT
 
pragma solidity ^0.8.10;

import "@openzeppelin/contracts/token/ERC721/ERC721.sol";
import "@openzeppelin/contracts/token/ERC721/IERC721Receiver.sol";

import "./Escrow.sol";

contract EscrowManager {

    address internal _owner; 

    event escrowCreated(address owner, address contractAddress);

    uint public totalContracts;
    address[] public escrowContracts;

    function addNewEscrow() public returns(address escrowAddress){
        NftEscrow newEscrow = new NftEscrow(address(msg.sender), address(0));
        address newContract = address(newEscrow);
        escrowContracts.push(newContract);
        totalContracts++;
        emit escrowCreated(msg.sender, newContract);
        return newContract;
    }

     function addNewEscrow(address buyer) public returns(address escrowAddress){
        NftEscrow newEscrow = new NftEscrow(address(msg.sender), buyer);
        address newContract = address(newEscrow);
        escrowContracts.push(newContract);
        totalContracts++;
        emit escrowCreated(msg.sender, newContract);
        return newContract;
    }
}